using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class TeamRepository : ITeamMembers
    {
        private TeamDBContext _context;
        public TeamRepository(TeamDBContext teamDBContext)
        {
            _context = teamDBContext;
        }
        public void DeleteMember(int memberId)
        {
            TeamMembers team = _context.TeamMembersAll.Find(memberId);
            _context.TeamMembersAll.Remove(team);
        }

        public TeamMembers GetMemberByID(int memberId)
        {
            return _context.TeamMembersAll.Find(memberId);
        }

        public IEnumerable<TeamMembers> GetMembers()
        {
            return _context.TeamMembersAll.ToList();
        }

        public void InsertMember(TeamMembers Team)
        {
             _context.TeamMembersAll.Add(Team);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCoachMembers(List<TeamMembers> Team)
        {
            using (_context)
            {
                foreach (var i in Team)
                {
                    var c = _context.TeamMembersAll.Where(a => a.Id.Equals(i.Id)).FirstOrDefault();
                    if (c != null)
                    {
                        

                        c.IsSelected = i.IsSelected;
                        c.IsPlaying = i.IsPlaying;
                        c.IsCaptain = i.IsCaptain;

                    }
                    _context.Entry(c).State = EntityState.Modified;
                }

                _context.SaveChanges();
            }
           
        }
        public void UpdateCaptainMembers(List<TeamMembers> Team)
        {
            using (_context)
            {
                foreach (var i in Team)
                {
                    var c = _context.TeamMembersAll.Where(a => a.Id.Equals(i.Id)).FirstOrDefault();
                    if (c != null)
                    {
                        

                        //c.IsSelected = i.IsSelected;
                        c.IsPlaying = i.IsPlaying;
                        //c.IsCaptain = i.IsCaptain;

                    }
                    _context.Entry(c).State = EntityState.Modified;
                }

                _context.SaveChanges();
            }

        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TeamRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
