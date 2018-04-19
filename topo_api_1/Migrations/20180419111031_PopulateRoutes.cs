using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.ApplicationInsights.AspNetCore;

namespace topo_api_1.Migrations
{
    public partial class PopulateRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Migrations/MockRoute.sql");
            string sql = File.ReadAllText(sqlFile);
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
