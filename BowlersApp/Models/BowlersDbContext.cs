﻿using System;
using Microsoft.EntityFrameworkCore;

namespace BowlersApp.Models
{
    public class BowlersDbContext : DbContext
    {
        public BowlersDbContext(DbContextOptions<BowlersDbContext> options) : base (options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
