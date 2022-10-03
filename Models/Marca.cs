namespace TPSNEAKERS.Models;


public class Marca{
    private int _ID_MARCA;
    private string _Nombre;
    private string _Fundadores;
    private string _Foto;
    private DateTime _Fecha_de_Fundación;
   

    public Marca(int ID_MARCA, string Nombre, string Fundadores, string Foto, DateTime FechaFundación){
        _ID_MARCA = ID_MARCA;
        _Nombre =Nombre;
        _Fundadores = Fundadores;
        _Foto = Foto;
        _Fecha_de_Fundación = FechaFundación;
      
    }

    public int ID_MARCA{
        get{
            return _ID_MARCA;
        } set{
            _ID_MARCA = value;
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
    public string Fundadores{
        get{
            return _Fundadores;
        } set{
            _Fundadores = value;
        }
    }
        public DateTime FechaFundación{
        get{
            return _Fecha_de_Fundación;
        } set{
            _Fecha_de_Fundación = value;
        }
    }
    public Marca(){
     
    }


  


}