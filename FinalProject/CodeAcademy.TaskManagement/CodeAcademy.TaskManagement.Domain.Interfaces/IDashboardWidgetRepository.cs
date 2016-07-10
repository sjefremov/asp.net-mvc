using CodeAcademy.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.TaskManagement.Domain.Interfaces
{
    public interface IDashboardWidgetRepository
    {
        IQueryable<DashboardWidget> GetAll(int userID);

        DashboardWidget GetById(int userID, int id);

        bool Update(int userID, DashboardWidget widget);

        bool SetVisibility(int userID, DashboardWidget widget);
        
    }
}
