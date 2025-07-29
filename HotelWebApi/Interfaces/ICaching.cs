namespace HotelWebApi.Interfaces
{
    public interface ICaching
    {
        public T GetorSet<T>(string key, Func<T> getData, int time);
        public Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> getData, int time);
        public void Remove(string key);
    }
}
