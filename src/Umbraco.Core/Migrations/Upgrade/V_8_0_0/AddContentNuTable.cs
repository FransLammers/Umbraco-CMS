﻿using System.Data;
using System.Linq;
using Umbraco.Core.Persistence.DatabaseAnnotations;
using Umbraco.Core.Persistence.Dtos;

namespace Umbraco.Core.Migrations.Upgrade.V_8_0_0
{
    class AddContentNuTable : MigrationBase
    {
        public AddContentNuTable(IMigrationContext context)
            : base(context)
        { }

        public override void Migrate()
        {
            var tables = SqlSyntax.GetTablesInSchema(Context.Database);
            if (tables.InvariantContains("cmsContentNu")) return;

            // FIXME how can we specify the OnDelete(Rule.Cascade) on the DTO?
            // FIXME are we creating other tables? need to make sure we don't created keys and indexes? or?
            Create.Table<ContentNuDto>(true).Do();

            //var textType = SqlSyntax.GetSpecialDbType(SpecialDbTypes.NTEXT);

            //Create.Table("cmsContentNu")
            //    .WithColumn("nodeId").AsInt32().NotNullable()
            //    .WithColumn("published").AsBoolean().NotNullable()
            //    .WithColumn("data").AsCustom(textType).NotNullable()
            //    .WithColumn("rv").AsInt64().NotNullable().WithDefaultValue(0)
            //    .Do();

            //Create.PrimaryKey("PK_cmsContentNu")
            //    .OnTable("cmsContentNu")
            //    .Columns(new[] { "nodeId", "published" })
            //    .Do();

            //Create.ForeignKey("FK_cmsContentNu_umbracoNode_id")
            //    .FromTable("cmsContentNu")
            //    .ForeignColumn("nodeId")
            //    .ToTable("umbracoNode")
            //    .PrimaryColumn("id")
            //    .OnDelete(Rule.Cascade)
            //    .OnUpdate(Rule.None)
            //    .Do();
        }
    }
}
