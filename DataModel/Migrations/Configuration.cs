namespace DataModel.Migrations
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.mFrameworkDbContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            ContextKey = "DataModel.mFrameworkDbContext";
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(DataModel.mFrameworkDbContext context)
        {
            string SeedDataPath = ConfigurationManager.AppSettings["SeedDataPath"].ToString();

            try
            {
                var xml = XDocument.Load(SeedDataPath);
                DepartmentMaster[] departments = xml.Element("SeedData").Element("departments")
                                .Elements("department")
                                .Select(x => new DepartmentMaster
                                {
                                    DepartmentId = (int)x.Element("DepartmentId"),
                                    DepartmentName = (string)x.Element("DepartmentName")
                                }).ToArray();

                context.departmentmaster.AddOrUpdate(
               p => p.DepartmentId, departments);
                UserMaster[] users = xml.Element("SeedData").Element("users")
                               .Elements("user")
                               .Select(x => new UserMaster
                               {
                                   UserId = (int)x.Element("UserId"),
                                   UserName = (string)x.Element("UserName"),
                                   UserPassword = (string)x.Element("UserPassword")
                               }).ToArray();

                context.usermaster.AddOrUpdate(
               p => p.UserId, users);
                RoleMaster[] Roles = xml.Element("SeedData").Element("Roles")
                               .Elements("Role")
                               .Select(x => new RoleMaster
                               {
                                   RoleId = (int)x.Element("RoleId"),
                                   RoleName = (string)x.Element("RoleName"),
                                   RoleStatus = (bool)x.Element("RoleStatus")
                               }).ToArray();

                context.rolemaster.AddOrUpdate(
               p => p.RoleId, Roles);
                RoleUserDetail[] RoleUsers = xml.Element("SeedData").Element("RoleUsers")
                               .Elements("RoleUser")
                               .Select(x => new RoleUserDetail
                               {
                                   RoleUserId = (int)x.Element("RoleUserId"),
                                   RoleId = (int)x.Element("RoleId"),
                                   UserId = (int)x.Element("UserId"),
                                   UserName = (string)x.Element("UserName")
                               }).ToArray();

                context.roleuserdtl.AddOrUpdate(
               p => p.RoleUserId, RoleUsers);
                MenuMaster[] Menus = xml.Element("SeedData").Element("Menus")
                               .Elements("Menu")
                               .Select(x => new MenuMaster
                               {

                                   MenuName = (string)x.Element("MenuName")

                               }).ToArray();
                context.menumaster.AddOrUpdate(
               p => p.MenuName, Menus);

                ScreenMaster[] Screens = xml.Element("SeedData").Element("Screens")
                              .Elements("Screen")
                              .Select(x => new ScreenMaster
                              {
                                  ScreenId = (int)x.Element("ScreenId"),
                                  MenuId = (int)x.Element("MenuId"),
                                  ScreenName = (string)x.Element("ScreenName"),
                                  ScreenUrl = (string)x.Element("ScreenUrl")
                              }).ToArray();

                context.screenmaster.AddOrUpdate(
               p => p.ScreenId, Screens);
                AccessControlList[] AccessLists = xml.Element("SeedData").Element("AccessLists")
                             .Elements("AccessList")
                             .Select(x => new AccessControlList
                             {
                                 AccesscontrolListId = (int)x.Element("AccesscontrolListId"),
                                 ScreenId = (int)x.Element("ScreenId"),
                                 RoleId = (int)x.Element("RoleId"),
                                 ScreenAccessId = (bool)x.Element("ScreenAccessId"),
                                 CanAdd = (bool)x.Element("CanAdd"),
                                 CanEdit = (bool)x.Element("CanEdit"),
                                 CanDelete = (bool)x.Element("CanDelete"),
                                 CanSearch = (bool)x.Element("CanSearch"),
                                 CanUpload = (bool)x.Element("CanUpload")

                             }).ToArray();

                context.accesscontrollist.AddOrUpdate(
               p => p.AccesscontrolListId, AccessLists);

                context.SaveChanges();
                //base.Seed(context);
            }
            catch
            {
                throw;
            }

        }
    }
}
