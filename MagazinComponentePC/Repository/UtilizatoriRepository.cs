using MagazinComponentePC.Data;
using MagazinComponentePC.Models;
using MagazinComponentePC.Models.DBObjects;

namespace MagazinComponentePC.Repository
{
    public class UtilizatoriRepository
    {
        private ApplicationDbContext dbContext;
        public UtilizatoriRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public UtilizatoriRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<UtilizatoriModel> GetAllUtilizatori()
        {
            List<UtilizatoriModel> utilizatoriList=new List<UtilizatoriModel>();
            foreach(Utilizatori dbUtilizatori in dbContext.Utilizatoris)
            {
                utilizatoriList.Add(MapDbObjectToModel(dbUtilizatori));
            }
            return utilizatoriList;
        }
        public UtilizatoriModel GetUtilizatorByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Utilizatoris.FirstOrDefault(x=>x.UserId == ID));
        }
        public void InsertUtilizator(UtilizatoriModel utilizatorModel)
        {
            utilizatorModel.UserId=Guid.NewGuid();
            dbContext.Utilizatoris.Add(MapModelToDbObject(utilizatorModel));
            dbContext.SaveChanges();
        }
        public void UpdateUtilizatori(UtilizatoriModel utilizatorModel)
        {
            Utilizatori existingUtilizator=dbContext.Utilizatoris.FirstOrDefault(x=>x.UserId==utilizatorModel.UserId);
            if(existingUtilizator!=null)
            {
                existingUtilizator.UserId=utilizatorModel.UserId;
                existingUtilizator.Nume=utilizatorModel.Nume;
                existingUtilizator.Email=utilizatorModel.Email;
                existingUtilizator.Parola=utilizatorModel.Parola;
                existingUtilizator.DataInregistrare=utilizatorModel.DataInregistrare;
                dbContext.SaveChanges();
            }
        }
        public void DeleteUtilizatori(UtilizatoriModel utilizatorModel)
        {
            Utilizatori existingUtilizator = dbContext.Utilizatoris.FirstOrDefault(x => x.UserId == utilizatorModel.UserId);
            if(existingUtilizator!=null )
            {
                dbContext.Utilizatoris.Remove(existingUtilizator);
                dbContext.SaveChanges();
            }
        }
        private UtilizatoriModel MapDbObjectToModel(Utilizatori dbUtilizatori)
        {
            UtilizatoriModel utilizatoriModel = new UtilizatoriModel();
            if(dbUtilizatori !=null)
            {
                utilizatoriModel.UserId=dbUtilizatori.UserId;
                utilizatoriModel.Nume = dbUtilizatori.Nume;
                utilizatoriModel.Email = dbUtilizatori.Email;
                utilizatoriModel.Parola = dbUtilizatori.Parola;
                utilizatoriModel.DataInregistrare = dbUtilizatori.DataInregistrare;
            }
            return utilizatoriModel;
        }
        private Utilizatori MapModelToDbObject(UtilizatoriModel utilizatoriModel)
        {
            Utilizatori utilizatori= new Utilizatori();
            if(utilizatoriModel!=null)
            {
                utilizatori.UserId = utilizatoriModel.UserId;
                utilizatori.Nume = utilizatoriModel.Nume;
                utilizatori.Email = utilizatoriModel.Email;
                utilizatori.Parola = utilizatoriModel.Parola;
                utilizatori.DataInregistrare = utilizatoriModel.DataInregistrare;
            }
            return utilizatori;
        }
    }
}
