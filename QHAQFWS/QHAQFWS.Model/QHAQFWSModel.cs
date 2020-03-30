namespace QHAQFWS.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QHAQFWSModel : DbContext
    {
        public QHAQFWSModel()
            : base("name=QHAQFWS")
        {
        }

        public virtual DbSet<Air_CityAQIHistory_Day_App> Air_CityAQIHistory_Day_App { get; set; }
        public virtual DbSet<Air_CityAQIHistory_Day_App_Std> Air_CityAQIHistory_Day_App_Std { get; set; }
        public virtual DbSet<Air_CityAQIHistory_Day_Pub> Air_CityAQIHistory_Day_Pub { get; set; }
        public virtual DbSet<Air_CityAQIHistory_Day_Pub_Std> Air_CityAQIHistory_Day_Pub_Std { get; set; }
        public virtual DbSet<Air_CityAQIHistory_Day_Src> Air_CityAQIHistory_Day_Src { get; set; }
        public virtual DbSet<Air_CityAQIHistory_Day_Src_Std> Air_CityAQIHistory_Day_Src_Std { get; set; }
        public virtual DbSet<Air_CityAQIHistory_H_App> Air_CityAQIHistory_H_App { get; set; }
        public virtual DbSet<Air_CityAQIHistory_H_App_Std> Air_CityAQIHistory_H_App_Std { get; set; }
        public virtual DbSet<Air_CityAQIHistory_H_Pub> Air_CityAQIHistory_H_Pub { get; set; }
        public virtual DbSet<Air_CityAQIHistory_H_Pub_Std> Air_CityAQIHistory_H_Pub_Std { get; set; }
        public virtual DbSet<Air_CityAQIHistory_H_Src> Air_CityAQIHistory_H_Src { get; set; }
        public virtual DbSet<Air_CityAQIHistory_H_Src_Std> Air_CityAQIHistory_H_Src_Std { get; set; }
        public virtual DbSet<Air_StationAQIHistory_Day_App> Air_StationAQIHistory_Day_App { get; set; }
        public virtual DbSet<Air_StationAQIHistory_Day_App_Std> Air_StationAQIHistory_Day_App_Std { get; set; }
        public virtual DbSet<Air_StationAQIHistory_Day_Pub> Air_StationAQIHistory_Day_Pub { get; set; }
        public virtual DbSet<Air_StationAQIHistory_Day_Pub_Std> Air_StationAQIHistory_Day_Pub_Std { get; set; }
        public virtual DbSet<Air_StationAQIHistory_Day_Src> Air_StationAQIHistory_Day_Src { get; set; }
        public virtual DbSet<Air_StationAQIHistory_Day_Src_Std> Air_StationAQIHistory_Day_Src_Std { get; set; }
        public virtual DbSet<Air_StationAQIHistory_H_App> Air_StationAQIHistory_H_App { get; set; }
        public virtual DbSet<Air_StationAQIHistory_H_App_Std> Air_StationAQIHistory_H_App_Std { get; set; }
        public virtual DbSet<Air_StationAQIHistory_H_Pub> Air_StationAQIHistory_H_Pub { get; set; }
        public virtual DbSet<Air_StationAQIHistory_H_Pub_Std> Air_StationAQIHistory_H_Pub_Std { get; set; }
        public virtual DbSet<Air_StationAQIHistory_H_Src> Air_StationAQIHistory_H_Src { get; set; }
        public virtual DbSet<Air_StationAQIHistory_H_Src_Std> Air_StationAQIHistory_H_Src_Std { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<SyncDataQueue> SyncDataQueue { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_App_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Pub_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_Day_Src_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_App_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Pub_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_CityAQIHistory_H_Src_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_App_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Pub_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.SO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.CO_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.NO2_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.O3_8h_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.PM10_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.PM2_5_24h)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_Day_Src_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.COMark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.NO2Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.O3Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.PM10Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.PM2_5Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.SO2Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.COMark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.NO2Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.O3Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.PM10Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.PM2_5Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.SO2Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_App_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Pub_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.COMark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.NO2Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.O3Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.PM10Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.PM2_5Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.SO2Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.CO)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.NO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.O3)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.PM10)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.PM2_5)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.SO2)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.COMark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.NO2Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.O3Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.PM10Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.PM2_5Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.SO2Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.AQI)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.PrimaryPollutant)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Air_StationAQIHistory_H_Src_Std>()
                .Property(e => e.Unheathful)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.PositionName)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.UniqueCode)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.StationCode)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.PollutantCodes)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Latitude)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Manager)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
