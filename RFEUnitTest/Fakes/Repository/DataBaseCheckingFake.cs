using RFETest.DataBase;
using RFETest.Models;

namespace RFEUnitTest.Fakes.Repository
{
    public class DataBaseCheckingFake : IDataBaseChecking
    {
        private InputDb repository;
        public bool CheckDirectionsSize(List<InputData> inMemoryData, string[] directions)
        {
            return Equals(inMemoryData.Where(m => m.InputType == directions[0]).Select(d => d.Input.Length).Single(),
                        inMemoryData.Where(m => m.InputType == directions[1]).Select(d => d.Input.Length).Single());
        }

        public bool CheckDirectionsValues(List<InputData> inMemoryData, string[] directions)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfIdIsInDb(List<InputData> inMemoryData, string id)
        {
            return Task.FromResult(inMemoryData.Select(d => d.InputId).Contains(id));
        }
    }
}
