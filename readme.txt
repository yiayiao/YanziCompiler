DFA ״̬ת����
��fir_cΪ�ӻ�����������ȡ����Ԫ�أ�sec_cΪ��ǰ��������һ��Ԫ�أ�

��ʼ״̬��ʼת��
1.beginState �޸�Ϊfalse
2.���Ϊ˫Ŀ���������sec_c�ӻ�������ȡ����content = string.format("{0}{1}", fir_c, sec_c), תΪ��ʼ״̬
3.���Ϊ"//"����"/*", ��sec_c�ӻ�������ȡ����content = string.format("{0}{1}", fir_c, sec_c), ״̬ת��ΪWordType.Comment, �ڴ���һ����״̬ת��
4.���Ϊ"0X"����"0x", ��sec_c�ӻ�������ȡ����content = string.format("{0}{1}", fir_c, sec_c), ״̬ת��ΪWordType.Hexadecimal, �ڴ���һ����״̬ת��
5.���fir_c = "\"", content += fir_c, ״̬ת��Ϊ WordType.StringConstant
6.���fir_c = "'", content += fir_c, ״̬ת��Ϊ WordType.CharConstant
7.���fir_c = '-', ���ܴ�������ת��������: 06 WordType.Octonary, 0a WordType.Illegal��0. WordType.FloatConstant��0{ ����0��ת�����״̬
8.���fir_c ���֣���������ת�������������Ƿ���ʮ���ƣ�����״̬������sec_c Ϊ','�ȣ�
9.����Ǵ�Сд��ĸ����_��״̬Ϊ��ʶ��������״̬����
10.���(fir_c == '{' || fir_c == '}' || fir_c == ';')
11.������

�ǳ�ʼ״̬��ʼת��

