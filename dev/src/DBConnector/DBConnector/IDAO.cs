using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.IF
{
	public interface IDAO
	{
		object SelectAll();
		object Select(object dto);
		object Insert(object dto);
		object Update(object dto);
		object Delete(object dto);
	}
}
