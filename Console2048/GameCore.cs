using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    /// <summary>
    /// 游戏核心类(处理游戏核心算法)
    /// </summary>
    class GameCore
    {
        private int[,] array;
        public int[,] Map
        {
            get
            {
                return array;
            }
        }
        private int[] operatingArray;
        private int[] afterMoveZeroArray;
        private Random random;
        private int[,] tempMap;
        public bool isChange;
        public bool isGameOver;
        //建立一个统计空位的列表
        private List<EmptyLocation> emptyLocationList;
        public GameCore()
        {
            array = new int[4, 4];
            operatingArray = new int[4];
            afterMoveZeroArray = new int[4];
            emptyLocationList = new List<EmptyLocation>(16);
            random = new Random();
            tempMap = new int[4, 4];
        }
        //控制移动：
        private void MoveZero()
        {
            Array.Clear(afterMoveZeroArray,0,4);
            int noZeroPosition = 0;
            for (int i = 0; i < operatingArray.Length; i++)
            {
                if (operatingArray[i] != 0)
                {
                    afterMoveZeroArray[noZeroPosition++] = operatingArray[i];
                }
            }
            for (int i = 0; i < operatingArray.Length; i++)
            {
                operatingArray[i] = afterMoveZeroArray[i];
            }
        }
        private void CombineNumber()
        {
            MoveZero();
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                if (operatingArray[i] == operatingArray[i + 1])
                {
                    operatingArray[i] += operatingArray[i + 1];
                    operatingArray[i + 1] = 0;
                }
            }
            MoveZero();
        }
        private void CtrlUp()
        {
            for (int row = 0; row < array.GetLength(1); row++)
            {
                for (int line = 0; line < operatingArray.Length; line++)
                {
                    operatingArray[line] = array[line, row];
                }
                CombineNumber();
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    array[i, row] = operatingArray[i];
                }
            }
        }
        private void CtrlDown()
        {
            for (int row = 0; row < array.GetLength(1); row++)
            {
                for (int line = 0; line < operatingArray.Length; line++)
                {
                    operatingArray[line] = array[line, row];
                }
                Array.Reverse(operatingArray);
                CombineNumber();
                Array.Reverse(operatingArray);
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    array[i, row] = operatingArray[i];
                }
            }
        }
        private void CtrlLeft()
        {
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < operatingArray.Length; row++)
                {
                    operatingArray[row] = array[line, row];
                }
                CombineNumber();
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    array[line, i] = operatingArray[i];
                }
            }
        }
        private void CtrlRight()
        {
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < operatingArray.Length; row++)
                {
                    operatingArray[row] = array[line, row];
                }
                Array.Reverse(operatingArray);
                CombineNumber();
                Array.Reverse(operatingArray);
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    array[line, i] = operatingArray[i];
                }
            }
        }
        public void EnumerateMove(MoveDirection direction)
        {
            //移动之前先将现在的地图复制一份
            Array.Copy(array,tempMap,array.Length);
            isChange = false;//默认地图没有发生变化
            switch (direction)
            {
                case MoveDirection.Up:
                    CtrlUp();
                    break;
                case MoveDirection.Down:
                    CtrlDown();
                    break;
                case MoveDirection.Left:
                    CtrlLeft();
                    break;
                case MoveDirection.Right:
                    CtrlRight();
                    break;
            }
            //判断移动之后的地图是否和原来的一样
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < array.GetLength(1); row++)
                {
                    if (tempMap[line,row] != array[line,row])
                    {
                        isChange = true;//若一样标记地图发生了变化
                        return;
                    }
                }
            }
        }
        //随机生成数字：
        //需求：在空白位置随机生成数字 2 (90%) 和数字 4 (10%)
        //分析：
        /*
        (1)计算空白位置
        (2)随机选择一个空白位置
        (3)随机填入数字 2 或数字 4
        */
        private void GetEmptyLocation()
        {
            //每次统计空位之前先清空列表，以免溢出
            emptyLocationList.Clear();
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < array.GetLength(1); row++)
                {
                    if (array[line,row] == 0)
                    {
                        //将空位存在列表中，列表是一个自定义数据类型 EmptyLocation 的数组
                        //自定义数据类型 EmptyLocation 用来记录行列信息
                        emptyLocationList.Add(new EmptyLocation(line, row));
                    }
                }
            }
        }
        public void FillInRandomNumber()
        {
            //先获取一下空位置有哪些
            GetEmptyLocation();
            if (emptyLocationList.Count > 0)//有空位置产生，无空位置不产生
            {
                int randomBlank = random.Next(0, emptyLocationList.Count);
                //在空位列表中随机挑选一个空位的位置赋值给变量 fillInIndex
                EmptyLocation fillInIndex = emptyLocationList[randomBlank];
                //将空位的行和列填入数组，并给对应元素赋值 2 或 4 (随机数拟合概率)(三元运算符填入)
                array[fillInIndex.LineIndex, fillInIndex.RowIndex] = random.Next(0, 10) == 0 ? 4 : 2;
            }
        }
        //控制游戏结束：没有空位置且不能合并
        public void GameOver()
        {
            isGameOver = false;
            GetEmptyLocation();
            if (emptyLocationList.Count == 0)
            {
                for (int line = 0; line < 4; line++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        if (array[line, row] == array[line, row + 1] || array[row, line] == array[row + 1, line])
                        {
                            return;
                        }    
                    }
                }
                isGameOver = true;
            }
        }
    }
}
