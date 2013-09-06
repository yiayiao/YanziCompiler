DFA 状态转换：
（fir_c为从缓冲区队列中取出的元素，sec_c为当前缓冲区第一个元素）

初始状态开始转：
1.beginState 修改为false
2.如果为双目运算符，将sec_c从缓冲区中取出，content = string.format("{0}{1}", fir_c, sec_c), 转为开始状态
3.如果为"//"或者"/*", 将sec_c从缓冲区中取出，content = string.format("{0}{1}", fir_c, sec_c), 状态转化为WordType.Comment, 期待下一步的状态转化
4.如果为"0X"或者"0x", 将sec_c从缓冲区中取出，content = string.format("{0}{1}", fir_c, sec_c), 状态转化为WordType.Hexadecimal, 期待下一步的状态转化
5.如果fir_c = "\"", content += fir_c, 状态转换为 WordType.StringConstant
6.如果fir_c = "'", content += fir_c, 状态转换为 WordType.CharConstant
7.如果fir_c = '-', 可能存在四种转换，例如: 06 WordType.Octonary, 0a WordType.Illegal，0. WordType.FloatConstant，0{ 数字0，转入结束状态
8.如果fir_c 数字，存在三种转化，浮点数，非法，十进制，可能状态结束（sec_c 为','等）
9.如果是大小写字母或者_，状态为标识符，可能状态结束
10.如果(fir_c == '{' || fir_c == '}' || fir_c == ';')
11.操作符

非初始状态开始转：

