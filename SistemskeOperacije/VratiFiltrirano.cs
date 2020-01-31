﻿using Domen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{    
    public class VratiFiltrirano : OpstaSO
    {
        public List<IDomenskiObjekat> lista;

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            List<IDomenskiObjekat> rezultat = broker.Filtriaj(objekat);

            for (int i = 0; i < rezultat.Count;)
            {
                IDomenskiObjekat ido = rezultat[i];
                IDomenskiObjekat podDomen = ido.VratiPodDomen();

                if (podDomen != null)
                {
                    podDomen.PostaviVrednost(broker.Pronadji(podDomen)[0]);
                    ido.PostaviVrednostPodDomena(podDomen);

                    while (podDomen.VratiPodDomen() != null)
                    {
                        IDomenskiObjekat podPod = podDomen.VratiPodDomen();

                        podPod.PostaviVrednost(broker.Pronadji(podPod)[0]);
                        podDomen.PostaviVrednostPodDomena(podPod);
                    }
                }
                else
                {
                    i++;
                }
            }

            lista = rezultat;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {

        }
    }
}