using CineTeatro.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CineTeatro.DataLayer.EntityTypeConfigurations
{
    public class ButacaFuncionEntityTypeConfiguration : EntityTypeConfiguration<ButacaFuncion>
    {
        public ButacaFuncionEntityTypeConfiguration()
        {
            ToTable("ButacasFunciones");
        }
    }
}