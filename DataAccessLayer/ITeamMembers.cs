using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public interface ITeamMembers:IDisposable
    {
        IEnumerable<TeamMembers> GetMembers();
        TeamMembers GetMemberByID(int memberId);
        void InsertMember(TeamMembers Team);
        void DeleteMember(int memberId);
        void UpdateCoachMembers(List<TeamMembers> Team);
        void UpdateCaptainMembers(List<TeamMembers> Team);
        void Save();
    }
}
