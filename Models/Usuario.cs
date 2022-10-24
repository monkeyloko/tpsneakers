namespace TPSNEAKERS.Models;
public class Usuario{
    private int _ID_USUARIO;
    private string _Nombre;
      public int ID_MARCA{
        get{
            return _ID_USUARIO;
        } set{
            _ID_USUARIO = value;
        }
    }
    public string Nombre{
        get{
            return _Nombre;
        } set{
            _Nombre = value;
        }
    }
}