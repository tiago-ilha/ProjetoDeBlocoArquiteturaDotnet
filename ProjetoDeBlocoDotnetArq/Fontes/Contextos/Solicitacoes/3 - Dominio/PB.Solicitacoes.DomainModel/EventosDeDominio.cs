using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PB.Solicitacoes.DomainModel
{
    public static class EventosDeDominio
    {
        private static List<Type> _manipuladores = new List<Type>();

        public static void Iniciar()
        {
            ListarTodosOsBinarios().ForEach(assembly =>
            {
                var types = Assembly.Load(assembly.GetName())
                   .GetTypes()
                   .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IManipuladorDeEvento<>)))
                   .ToList();

                _manipuladores.AddRange(types);
            });
        }

        private static List<Assembly> ListarTodosOsBinarios()
        {
            var todosOsBinarios = new List<Assembly>();
            string caminhoDaAplicacao = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.GetFiles(caminhoDaAplicacao, "PB.Solicitacoes*.dll").ToList().ForEach(file =>
            {
                todosOsBinarios.Add(Assembly.LoadFile(file));
            });

            return todosOsBinarios;
        }
        
        public static void DespacharEvento<T>(T eventoDeDominio) where T : IEventoDeDominio
        {
            foreach (Type tipoDoManipulador in _manipuladores)
            {
                bool eventoPodeSerManipulado = tipoDoManipulador.GetInterfaces()
                    .Any(x => x.IsGenericType
                        && x.GetGenericTypeDefinition() == typeof(IManipuladorDeEvento<>)
                        && x.GenericTypeArguments[0].Name == eventoDeDominio.GetType().Name);

                if (eventoPodeSerManipulado)
                {
                    dynamic manipulador = Activator.CreateInstance(tipoDoManipulador);
                    manipulador.Executar((dynamic)eventoDeDominio);
                }                
            }
        }
    }

}