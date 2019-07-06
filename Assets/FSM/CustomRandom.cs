using UnityEngine;
using System.Collections;

public class CustomRandom 
{
	int nIndex;	// 가져온 배열 인덱스..
	int [] a = {0,1,2,3,4,5,6,7,8,9};

	void GetRandom(int min, int max)
	{
		// RAND_MAX :0~32767
		// rand()%n
		Suffle();

		// 최대값과 최소값의 자리수 구하기..
		int nMinDigit = Digit(min);
		int nMaxDigit = Digit(max);

		// 몇자이의 랜덤을 구할지를 결정.
	}

	public void PRINT()
	{
		GetRandom(0,100);

		for( int i = 0; i < 10; i++ )
		{
			Debug.Log( GetNumber(0, 9) );
		}
	}

	// min~max의 한자리수의 랜덤을 가져온다..
	int GetNumber(int min, int max)
	{
		if( nIndex > 9 )
			return -1;

		int z = 0;
		int tmp =0;
		for( z = 0; z< 10; z++)
		{
			tmp = a[z];
			if( tmp >= min && tmp <= max)
				return a[nIndex++];
		}
		return -1;
	}

	void Suffle()
	{
		int j;

		for( j = 0; j<10; j++)
		{
			int n1 = Random.Range(0,10);
			int n2 = Random.Range(0,10);

			int tmp = a[n1];
			a[n1] = a[n2];
			a[n2] = tmp;
		}
	}

	int Digit(int n)
	{
		//자리수를 구하기 때문에 0을 9로 교체한다.
		//숫자의 크기는 문제가 안된다.오로지 자리수..
		if( n <= 0 )
			n = 9;

		int k = 1, num_len = 0;
		while( n > k )
		{
			k *= 10;
			num_len++;
		}

		return num_len;
	}
}
