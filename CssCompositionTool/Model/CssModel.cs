using System.Data.Entity;

namespace CssCompositionTool.Model
{
    public partial class CssModel : DbContext
    {
        public CssModel() : base(CssCompositionToolPackage.ConnectionOther)  // base(@"Server=(localdb)\mssqllocaldb;Database=CssScriptClasses.db;Trusted_Connection=True;")  // "CssScriptClasses.db"
        {
            Database.CreateIfNotExists();
            
        }

        public virtual DbSet<CssAnimation> CssAnimations { get; set; }
        public virtual DbSet<CssColor> CssColors { get; set; }
        public virtual DbSet<CssColorType> CssColorTypes { get; set; }
        public virtual DbSet<CssStyle> CssStyles { get; set; }
        public virtual DbSet<CssStyleItem> CssStyleItems { get; set; }
        public virtual DbSet<CssTransition> CssTransitions { get; set; }

       

        


        //protected override void OnConfiguring(Microsoft.Data.Entity.DbContextOptionsBuilder optionsBuilder)
        //{
        //    string path = "Filename=" + Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\" +
        //                  "CssScriptClasses.db";

        //  //  Environment.UserName
        //    optionsBuilder.UseSqlite(path);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Visual Studio 2015 | Use the LocalDb 12 instance created by Visual Studio
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CssScriptClasses.db;Trusted_Connection=True;");

        //    // Visual Studio 2013 | Use the LocalDb 11 instance created by Visual Studio
        //    // optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=CssScriptClasses.db;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<CssColor>()
            //    .HasOne(e => e.CssColorType)
            //    .WithMany(e => e.CssColors)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<CssTransition>()
            //    .HasOne(e => e.CssStyle)
            //    .WithMany(e => e.CssTransitions)
            //    .HasForeignKey(e => e.StyleId);

            //modelBuilder.Entity<CssStyleItem>()
            //    .HasOne(e => e.CssStyle)
            //    .WithMany(e => e.CssStyleItems)
            //    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<CssColorType>()
                .HasMany(e => e.CssColors)
                .WithRequired(e => e.CssColorType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CssStyle>()
                .HasMany(e => e.CssTransitions)
                .WithOptional(e => e.CssStyle)
                .HasForeignKey(e => e.StyleId);

            modelBuilder.Entity<CssStyleItem>()
                .HasMany(e => e.CssColorTypes)
                .WithRequired(e => e.CssStyleItem)
                .WillCascadeOnDelete(false);

         

            //string connect = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\CssModel.sqlite";
            //Database.Connection.ConnectionString = connect;

            //var sqliteConnectionInitializer = new CssModelDbInitializer(modelBuilder);
            //Database.SetInitializer(sqliteConnectionInitializer);
        }
    }

    //public class CssModelDbInitializer : SqliteCreateDatabaseIfNotExists<CssModel>
    //{
    //    public CssModelDbInitializer(ModelBuilder modelBuilder) : base(modelBuilder)
    //    {

    //    }

    //    protected override void Seed(CssModel context)
    //    {

    //    }
    //}

    public static class VisibleServerList
    {
        public static System.Data.DataTable GetVisibleServers()
        {
            System.Data.Sql.SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
         
            return instance.GetDataSources();
        }
    }

}
