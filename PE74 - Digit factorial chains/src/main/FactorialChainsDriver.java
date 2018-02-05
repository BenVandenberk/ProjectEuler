package main;

public class FactorialChainsDriver {

	private int[] faculteiten;
	private int[] chain;
	private int aantalChainsVanZestig;

	public FactorialChainsDriver() {
		faculteiten = new int[10];
		aantalChainsVanZestig = 0;
		berekenFaculteiten();
	}

	public int getAantalChainsVanZestig() {
		return aantalChainsVanZestig;
	}

	public void run() {
		for (int i = 1; i < 1000000; i++) {
			aantalChainsVanZestig += heeftChainVanZestig(i) ? 1 : 0;
		}	
	}

	private boolean heeftChainVanZestig(int getal) {
		int chainLengte = 1;
		chain = new int[100];
		chain[0] = getal;
		
		do {			
			getal = getVolgendeGetalInChain(getal);
			chain[chainLengte] = getal;
			chainLengte++;
		} while (chainContainsOpPositie(getal, chainLengte - 1) < 0);
		
		return chainLengte - 1 == 60;
	}
	
	private int chainContainsOpPositie(int getal, int voorIndex) {
		for (int i = 0; i < voorIndex; i++) {
			if (chain[i] == getal) {
				return i;
			}
		}
		return -1;
 	}

	public int getVolgendeGetalInChain(int getal) {
		int somVanFaculteiten = 0;
		int temp;

		for (int mod = 1000000; mod >= 1; mod /= 10) {
			if (getal % mod == getal) {
				continue;
			}

			somVanFaculteiten += faculteiten[getal / mod];
			if (getal % mod == 0) {
				while (getal >= 10) {
					getal /= 10;
					somVanFaculteiten++;					
				}
				break;
			} else {
				temp = mod;
				while (getal % mod < mod / 10) {
					somVanFaculteiten++;
					mod /= 10;					
				}
				getal %= temp;
			}
		}

		return somVanFaculteiten;
	}

	private void berekenFaculteiten() {
		faculteiten[0] = 1;

		int faculteit = 1;
		for (int i = 1; i < 10; i++) {
			faculteit *= i;
			faculteiten[i] = faculteit;
		}
	}

}
