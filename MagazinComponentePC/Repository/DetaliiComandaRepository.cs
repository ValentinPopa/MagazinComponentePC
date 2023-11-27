/*using MagazinComponentePC.Data;
using MagazinComponentePC.Models.DBObjects;
using MagazinComponentePC.Models;

namespace MagazinComponentePC.Repository
{
    public class DetaliiComandaRepository
    {
        private ApplicationDbContext dbContext;
        public ProduseRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public ProduseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ProduseModel> GetAllProduse()
        {
            List<ProduseModel> produseList = new List<ProduseModel>();
            foreach (Produse dbProduse in dbContext.Produses)
            {
                produseList.Add(MapDbObjectToModel(dbProduse));
            }
            return produseList;
        }
        public ProduseModel GetProduseByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Produses.FirstOrDefault(x => x.ProdusId == ID));
        }
        public void InsertProduse(ProduseModel produsModel)
        {
            produsModel.ProdusId = Guid.NewGuid();
            dbContext.Produses.Add(MapModelToDbObject(produsModel));
            dbContext.SaveChanges();
        }
        public void UpdateUtilizatori(ProduseModel produsModel)
        {
            Produse existingProdus = dbContext.Produses.FirstOrDefault(x => x.ProdusId == produsModel.ProdusId);
            if (existingProdus != null)
            {
                existingProdus.ProdusId = produsModel.ProdusId;
                existingProdus.NumeProdus = produsModel.NumeProdus;
                existingProdus.Descriere = produsModel.Descriere;
                existingProdus.Pret = produsModel.Pret;
                existingProdus.Stoc = produsModel.Stoc;
                dbContext.SaveChanges();
            }
        }
        public void DeleteProdus(ProduseModel produseModel)
        {
            Produse existingProdus = dbContext.Produses.FirstOrDefault(x => x.ProdusId == produseModel.ProdusId);
            if (existingProdus != null)
            {
                dbContext.Produses.Remove(existingProdus);
                dbContext.SaveChanges();
            }
        }
        private ProduseModel MapDbObjectToModel(Produse dbProduse)
        {
            ProduseModel produseModel = new ProduseModel();
            if (dbProduse != null)
            {
                produseModel.ProdusId = dbProduse.ProdusId;
                produseModel.NumeProdus = dbProduse.NumeProdus;
                produseModel.Descriere = dbProduse.Descriere;
                produseModel.Pret = dbProduse.Pret;
                produseModel.Stoc = dbProduse.Stoc;
            }
            return produseModel;
        }
        private Produse MapModelToDbObject(ProduseModel produseModel)
        {
            Produse produse = new Produse();
            if (produse != null)
            {
                produse.ProdusId = produseModel.ProdusId;
                produse.NumeProdus = produseModel.NumeProdus;
                produse.Descriere = produseModel.Descriere;
                produse.Pret = produseModel.Pret;
                produse.Stoc = produseModel.Stoc;
            }
            return produse;
        }
    }
}
*/