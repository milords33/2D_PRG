using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerCreator.Stats
{
    public interface IStatClickable
    {
        void Initialize();
        event Action<IStatClickable> OnClicked;
    }
}
