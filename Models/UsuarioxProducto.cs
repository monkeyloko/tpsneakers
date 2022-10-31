namespace TPSNEAKERS.Models;
public class UsuarioxProducto{
    private int _ID_USUARIO;
    private int _ID_Producto;

    public UsuarioxProducto(int ID_USUARIO, int ID_Producto){
        _ID_USUARIO = ID_USUARIO;
        _ID_Producto = ID_Producto;
    }

    public int ID_USUARIO{
        get{
            return _ID_USUARIO;
        } set{
            _ID_USUARIO = value;
        }
    }
    public int ID_Producto{
        get{
            return _ID_Producto;
        } set{
            _ID_Producto = value;
        }
    }
    
} 