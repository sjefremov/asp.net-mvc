using CodeAcademy.TaskManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAcademy.TaskManagement.Domain.Entities;

namespace CodeAcademy.TaskManagement.RepositoryEF.Repositories
{
    public class DashboardWidgetRepository : IDashboardWidgetRepository
    {
        Database db = new Database();
        public IQueryable<DashboardWidget> GetAll(int userID)
        {
            return db.DashboardWidgets.Where(x => x.UserId == userID)
                                        .OrderBy(x => x.Position);
        }

        public DashboardWidget GetById(int userID, int id)
        {
            return GetAll(userID).FirstOrDefault(x => x.ID == id);
        }

        public bool SetVisibility(int userID, DashboardWidget widget)
        {
            var dbWidget = GetById(userID, widget.ID);
            dbWidget.IsVisible = widget.IsVisible;
            db.SaveChanges();

            return true;
        }

        public bool Update(int userID, DashboardWidget widget)
        {
            var dbWidget = GetById(userID, widget.ID);
            dbWidget.DisplayName = widget.DisplayName;
            dbWidget.Position = widget.Position;
            dbWidget.Size = widget.Size;

            db.SaveChanges();
            return true;
        }
    }
}
