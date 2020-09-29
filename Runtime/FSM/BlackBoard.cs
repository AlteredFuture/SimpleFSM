using System.Collections.Generic;

namespace FSM
{
    public class BlackBoard
    {
        private Dictionary<string, BlackBoardData> blackBoardData = new Dictionary<string, BlackBoardData>();


        public void SetData(string key, BlackBoardData data)
        {
            if (blackBoardData.ContainsKey(key))
            {
                blackBoardData[key] = data;
            }
            else
            {
                blackBoardData.Add(key, data);
            }
        }

        public BlackBoardData<T> SetData<T>(string key, T data)
        {
            if (blackBoardData.ContainsKey(key))
            {
                if (blackBoardData[key] is BlackBoardData<T> bbd)
                {
                    bbd.data= data;
                }
                else
                {
                    blackBoardData[key] = new BlackBoardData<T>(data);
                }
            }
            else
            {
                blackBoardData.Add(key, new BlackBoardData<T>(data));
            }

            return (BlackBoardData<T>) blackBoardData[key];
        }

        public BlackBoardData<T> GetBlackBoardData<T>(string key)
        {
            return (BlackBoardData<T>) blackBoardData[key];
        }

        public BlackBoardData GetData(string key)
        {
            return blackBoardData[key];
        }

        public T GetData<T>(string key)
        {
            if (!blackBoardData.ContainsKey(key))
                return default(T);

            return ((BlackBoardData<T>) blackBoardData[key]).data;
        }

    }

    public abstract class BlackBoardData
    {
        public abstract bool IsBool();
    }

    public class BlackBoardData<T> : BlackBoardData
    {
        private static int count;

        private int number;

        public BlackBoardData(T data)
        {
            number = count++;
            this.data = data;
        }

        public T data;

        public override bool IsBool() => (data is bool);
    }
}