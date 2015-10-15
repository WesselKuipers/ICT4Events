using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IReportContext
    {
        List<Report> GetAllByPost(Post post);
        Report GetByPostId(int id);
        Report Insert(Report location);
        bool Update(Report location);
        bool Delete(Report location);
    }
}
