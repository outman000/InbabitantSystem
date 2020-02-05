using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.Repository.InhabitantSystem
{
    public class ScoreFormIDComparer : IEqualityComparer<AddIdentitySearchResidentMiddle>
    {
        public bool Equals(AddIdentitySearchResidentMiddle x, AddIdentitySearchResidentMiddle y)
        {
            if (x == null)
                return y == null;
            return x.Id == y.Id;
        }

        public int GetHashCode(AddIdentitySearchResidentMiddle obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
