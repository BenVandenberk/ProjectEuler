package main;

public class CountingFractionsDriver {
	
	final int BOVENGRENS = 2;
	final int ONDERGRENS = 3;
	final int TOT_NOEMER;
	
	private long aantalBreuken;
	
	public CountingFractionsDriver(int tot) {
		aantalBreuken = 0L;
		TOT_NOEMER = tot;
	}
	
	public long getAantalBreuken() {
		return aantalBreuken;
	}
	
	public void run() {
		for (int noemer = 2; noemer <= TOT_NOEMER; noemer++) {
			aantalBreuken += aantalBreukenVoor(noemer);
		}
	}
	
	private int aantalBreukenVoor(int noemer) {
		int startTeller = noemer / ONDERGRENS + 1;
		int eindTeller = noemer % BOVENGRENS == 0 ? noemer / BOVENGRENS - 1: noemer / BOVENGRENS;
		int aantal = 0;
		
		for (int teller = startTeller; teller <= eindTeller; teller++) {
			aantal += areRelativePrimes(noemer, teller) ? 1 : 0;
		}
		
		return aantal;
	}
	
	private boolean areRelativePrimes(int grootste, int kleinste) {
		int temp;

		while (kleinste > 0) {
			grootste %= kleinste;
			temp = grootste;
			grootste = kleinste;
			kleinste = temp;
		}
		
		return grootste == 1;
	}

}
