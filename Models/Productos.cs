namespace TPSNEAKERS.Models;

public class Productos{
    private int _ID_Producto;
    private string _Nombre;
    private string _Foto;
private int _FK_marca;
   

    public Productos(int ID_Producto, string Nombre, string Foto, int FK_marca){
        _ID_Producto = ID_Producto;
        _Nombre = Nombre;
        _Foto = Foto;
        _FK_marca = FK_marca;
      
    }

    public int ID_Producto{
        get{
            return _ID_Producto;
        } set{
            _ID_Producto = value;
        }
    }

    public string Nombre{
        get{
            return _Nombre;
        } set{
            _Nombre = value;
        }
    }
   
    public string Foto{
        get{
            return _Foto;
        } set{
            _Foto = value;
        }
    }
    public int FK_marca{
        get{
            return _FK_marca;
        } set{
            _FK_marca = value;
        }
    }

    public Productos(){
     
    }


  


}