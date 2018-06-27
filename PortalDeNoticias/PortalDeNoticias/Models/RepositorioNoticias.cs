using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalDeNoticias.Models
{
    public class RepositorioNoticias
    {

        private static List<Noticia> noticias;

        public static List<Noticia> Noticias
        {
            get
            {
                if (noticias ==null)                
                    CriarNoticias();
                return noticias;               
                    
            }
        }

        private static void CriarNoticias()
        {
            noticias = new List<Noticia>();

            noticias.Add(new Noticia
            {
                Id = 1,
                Titulo = "Titulo 1",
                Autor = "João Carlos",
                Data = DateTime.Today,
                Conteudo = "Lorem ipsum ultrices consequat aenean vitae donec, lectus consequat ullamcorper suspendisse. ipsum tellus integer auctor tempus tellus laoreet mollis leo rhoncus bibendum elementum tellus vitae felis, eu sit nullam nam platea consequat vivamus scelerisque tortor dictumst habitasse imperdiet. lorem fermentum consectetur nibh pretium himenaeos ornare senectus rhoncus tristique, elit enim condimentum rutrum at "

            });
            noticias.Add(new Noticia
            {
                Id = 2,
                Titulo = "Titulo 2",
                Autor = "João Carlos",
                Data = DateTime.Today,
                Conteudo = "Etiam varius felis molestie tempus, donec pretium erat nam ut, nec porttitor ultricies. nec taciti consectetur commodo et mi pharetra ullamcorper, magna suspendisse varius lorem diam lectus, varius aliquet et vehicula fringilla in. commodo laoreet lacinia tempus ornare viverra dictum curae est justo sollicitudin, suspendisse mi aliquam tortor vitae sem class ullamcorper tortor mauris platea, cras massa  "

            });
            noticias.Add(new Noticia
            {
                Id = 3,
                Titulo = "Titulo 3",
                Autor = "João Carlos",
                Data = DateTime.Today,
                Conteudo = "Habitasse potenti nisi sem nibh inceptos ultricies ipsum urna per, aptent turpis elementum vitae lobortis interdum etiam viverra orci varius, sodales accumsan pretium mattis vulputate eleifend rutrum nunc. venenatis tempus at vestibulum cursus litora, nisl lectus vulputate augue, odio"

            });
            noticias.Add(new Noticia
            {
                Id = 4,
                Titulo = "Titulo 4",
                Autor = "João Carlos",
                Data = DateTime.Today,
                Conteudo = " felis donec facilisis quisque, a rhoncus ullamcorper neque et tempor. aliquet leo mollis euismod eu etiam potenti etiam, pretium venenatis nisi lacus velit consequat. integer semper conubia gravida"

            });
        }
    }
}