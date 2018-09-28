using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AD;
using System.Data;

namespace BL
{
  public class BLUser
  {
    private ADUser objADUser;
    public BLUser()
    {
      objADUser = new ADUser();
    }
      
    public Boolean login(String user,String password)
    {
      return objADUser.login(user,password);
    }

    public Int32 usuarioId(String user)
    {
        return objADUser.usuarioId(user);
    }

    public Boolean permisoEliminarVoucherTodos(Int32 usuarioID)
    {
        return objADUser.permisoEliminarVoucherTodos(usuarioID);
    }

    public DataTable fnUsuariosAll()
    {
        return objADUser.fnUsuariosAll();
    }


  }
}
