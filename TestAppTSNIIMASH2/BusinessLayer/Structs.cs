using System;
/// <summary> ��������� ��� �������� ���������� �������� �����</summary>
public struct EopParam
{
	/// <summary>������� ���������� (1 - �������� ��������, 2 - ��������������)</summary>
	public double DataNo;
	/// <summary>����� �������������� ������ (������ = 0h �����) �� ����� UTC</summary>
	public DateTime T;
	/// <summary>���������� x ����������� ������ �� 0h ����� �� ����� UT� [�]</summary>
	public double Xp;
	/// <summary>����������� ���������� x ����������� ������ �� 0h ����� �� ����� UT� [�]</summary>
	public double ErrorX;
	/// <summary>���������� y ����������� ������ �� 0h ����� �� ����� UT� [�]</summary>
	public double Yp;
	/// <summary>����������� ���������� y ����������� ������ �� 0h ����� �� ����� UT� [�]</summary>
	public double ErrorY;
	/// <summary>�������� �������� deltaUT1 �� 0h ����� �� ����� UT� [�]</summary>
	public double DeltaUt1;
	/// <summary>����������� �������� �������� deltaUT1 �� 0h ����� �� ����� UT� [�]</summary>
	public double ErrorDeltaUt1;

}