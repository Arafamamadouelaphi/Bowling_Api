using BowlingEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingEF.Context
{
    /// <summary>
    /// Cette classe est le contexte de la base de données qui permet de faire le lien entre les objets et la base de données
    /// </summary>
    public class BowlingContext : DbContext
    {
        public DbSet<JoueurEntity> Joueurs { get; set; }
        public DbSet<EquipeEntity> Equipes { get; set; }
        public DbSet<PartieEntity> Parties { get; set; }
        public DbSet<FrameEntity> Frames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bowling.db");
        }

    }
}
