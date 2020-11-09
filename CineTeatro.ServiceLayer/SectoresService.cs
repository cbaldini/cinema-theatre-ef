using CineTeatro.ServiceLayer.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineTeatro.Common.Entities;
using System.Data.SqlClient;
using CineTeatro.DataLayer.Repositories.Facades;

namespace CineTeatro.ServiceLayer
{
    public class SectoresService : ISectoresService
    {
        private ISectoresRepositorio repositorioSectores;

        public SectoresService(ISectoresRepositorio repositorioSectores)
        {
            this.repositorioSectores = repositorioSectores;
        }
        public void Borrar(Sector sector)
        {
            repositorioSectores.Borrar(sector);
        }

        public void Editar(Sector sector)
        {
            repositorioSectores.Editar(sector);
        }

        public bool EsUnico(string descripcion)
        {
            return repositorioSectores.EsUnico(descripcion);
        }

        public List<Sector> GetLista(int? id)
        {
            return repositorioSectores.GetLista(id);
        }

        public Sector GetObjeto(int id)
        {
            return repositorioSectores.GetObjeto(id);
        }

        public void Guardar(Sector sector)
        {
            repositorioSectores.Guardar(sector);
        }
    }
}
