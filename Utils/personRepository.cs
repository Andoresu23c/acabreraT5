using acabreraS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace acabreraS5.Utils
{
    public class personRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new (_dbPath);
            conn.CreateTable<Persona>();
        }
        public personRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void addNewPerson(string name) 
        {
            int result = 0;
            try
            {
                Init();

                if(string.IsNullOrEmpty(name))
                {
                    throw new Exception("Nombre Requerido");
                }

                Persona person = new() { Name = name };
                result = conn.Insert(person);

                StatusMessage = string.Format("{0} records added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Failed to add {0}. Error: {1}", ex.Message);
            }
            return new List<Persona>();
        }

        public void UpdatePerson(Persona person)
        {
            int result = 0;
            try
            {
                Init();
                if (person == null || string.IsNullOrEmpty(person.Name))
                {
                    throw new Exception("Persona no válida");
                }
                result = conn.Update(person);
                StatusMessage = string.Format("{0} records updated (Name: {1})", result, person.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update {0}. Error: {1}", person.Name, ex.Message);
            }
        }

        public void DeletePerson(int id)
        {
            int result = 0;
            try
            {
                Init();
                result = conn.Delete<Persona>(id);
                StatusMessage = string.Format("{0} records deleted (ID: {1})", result, id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete record. Error: {0}", ex.Message);
            }
        }


    }
}
