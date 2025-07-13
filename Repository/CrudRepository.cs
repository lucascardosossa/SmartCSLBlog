using System.Linq.Expressions;

namespace SmartCSLBlog.Repository
{
    public class CrudRepository<T> where T : class, new()
    {
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        //static SQLiteAsyncConnection Database;
        //static SQLiteConnection DatabaseSync;

        protected static Context context = context ?? new Context();

        /// <summary>
        /// Método que remove todos os registros da Tabela
        /// </summary>
        /// <returns></returns>
        public static void RemoveAll()
        {
            try
            {
                context.database.DeleteAll<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Remove todos os registro, separado para a rotina de limpar base
        /// </summary>
        /// <returns></returns>
        public static int LimparBaseAsync()
        {
            try
            {
                //await Init();
                return context.database.DeleteAll<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int LimparBaseSinc()
        {
            try
            {
                //InitSync();
                return context.database.DeleteAll<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Método que remove o registro de acordo a expressão
        /// </summary>
        /// <param name="where">Expressão</param>
        /// <returns></returns>
        public static void Remove(Expression<Func<T, bool>> where)
        {
            try
            {
                //await Init();
                context.database.Table<T>().Where(where).Delete();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Método que retorna a quantidade de registros da tabela
        /// </summary>
        /// <returns>Inteiro</returns>
        public static int CountAll()
        {
            try
            {
                //await Init();
                return context.database.Table<T>().Count();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por gravar na tabela uma lista de registros informados
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static void Inserir(IEnumerable<T> t)
        {
            try
            {
                //await Init();
                context.database.InsertAll(t);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Método responsável por gravar na tabela um registro informado
        /// </summary>
        /// <param name="conf"></param>
        /// <returns></returns>
        public static void Inserir(T conf)
        {
            try
            {
                //await Init();
                context.database.Insert(conf);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Método responsável por alterar o registro na sua tabela
        /// </summary>
        /// <param name="conf"></param>
        /// <returns></returns>
        public static void Alterar(T conf)
        {
            try
            {
                //await Init();
                context.database.Update(conf);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por retornar o primeiro registro da tabela
        /// </summary>
        /// <returns>Objeto</returns>
        public static T Obter()
        {
            try
            {
                //await Init();
                return context.database.Table<T>().FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Método de busca que retorna o primeiro registro encontrado de acordo a expressão informada, não retorna nulo
        /// </summary>
        /// <param name="where"></param>
        /// <returns>Objeto</returns>
        public static T ObterFirstOrDefault(Expression<Func<T, bool>> where)
        {
            try
            {
                //await Init();
                return context.database.Table<T>().FirstOrDefault(where);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Método de busca que retorna o primeiro registro encontrado de acordo a expressão informada, pode retornar nulo
        /// </summary>
        /// <param name="where"></param>
        /// <returns>Objeto</returns>
        public static T GetFirst(Expression<Func<T, bool>> where)
        {
            try
            {
                //await Init();
                return context.database.Table<T>().First(where);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Método de busca que retorna todos os registros encontrados pela expressão informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns>Lista de Objetos</returns>
        public static List<T> Obter(Expression<Func<T, bool>> where)
        {
            try
            {
                //await Init();
                return context.database.Table<T>().Where(where).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Método de busca que retorna todos os registros da tabela
        /// </summary>
        /// <returns>Lista de Objeto</returns>
        public static List<T> Todos()
        {
            try
            {
                //await Init();
                return context.database.Table<T>().ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método de busca que retorna todos os registros pela expressão informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns>Lista de Objeto</returns>
        public static List<T> Todos(Expression<Func<T, bool>> where)
        {
            try
            {
                //await Init();
                return context.database.Table<T>().Where(where).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
