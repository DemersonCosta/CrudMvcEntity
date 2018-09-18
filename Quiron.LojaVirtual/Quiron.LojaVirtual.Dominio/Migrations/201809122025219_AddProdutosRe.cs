namespace Quiron.LojaVirtual.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProdutosRe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Produtos", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Produtos", "Categoria", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Categoria", c => c.String());
            AlterColumn("dbo.Produtos", "Descricao", c => c.String());
            AlterColumn("dbo.Produtos", "Nome", c => c.String());
        }
    }
}
