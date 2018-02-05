package main;

/**
 * Door (lang) te prullen op papier kwam ik tot volgend algoritme:
 * 
 * Neem f(x, y) als de functie die het aantal mogelijke sommen geeft om x te bekomen, gebruik makend van
 * gehele getallen in het interval [1, y]
 * 
 * De vraagstelling luidt dan om f(100, 99) te berekenen.
 * 
 * Op papier heb ik gezocht naar 'vereenvoudigingsregels' om f(x, y) te schrijven als een som van f(xi, yi),
 * waarbij xi < x || yi < y. Een set van regels bleek:
 * 
 * [1] Als x = y + 1, dan is f(x, y) = f(y, 1) + f(y - 1, 2) + ... + f(1, 1), waarbij altijd moet gelden dat
 *     y <= x
 * [2] Als x = y, dan is f(x, y) = 1 + f(x, y - 1)
 * [3] Als x > y + 1, dan is f(x, y) = f(x - y, y) + f(x - (y - 1), y - 1) + ... + f(x - 1, 1), waarbij altijd
 *     moet gelden dat y >= 1
 * [4] Als x < y, dan is f(x, y) = f(x, x)
 * [5] Als y = 1, dan is f(x, y) = 1 (= stopregel)
 * 
 * De method aantalSommen(int, int) voert deze vereenvoudigingsregels recursief toe om tot het juiste antwoord
 * te komen.
 * 
 * Uitvoeringstijd is juist onder een seconde.
 *
 * @author Ben
 *
 */
public class SummationCounter {

	private int getal;
	private long aantalSommen;

	public SummationCounter(int getal) {
		this.getal = getal;
		aantalSommen = 0;
	}

	public void run() {
		aantalSommen = aantalSommen(getal, getal - 1);
	}

	public int getGetal() {
		return getal;
	}

	private long aantalSommen(int x, int y) {
		long nrOfSommen = 0;

		if (y == 1) {
			return 1;
		}
		if (x == y) {
			return 1 + aantalSommen(x, y - 1);
		}
		if (x == y + 1) {
			int xU = y;
			int yU = 1;
			for (; xU >= 1; xU--, yU++) {
				if (yU > xU) {
					nrOfSommen += aantalSommen(xU, xU);
				} else {
					nrOfSommen += aantalSommen(xU, yU);
				}
			}
		}
		if (x > y + 1) {
			int xU = x - y;
			int yU = y;
			for (; yU >= 1; yU--, xU++) {
				nrOfSommen += aantalSommen(xU, yU);
			}
		}
		if (x < y) {
			nrOfSommen += aantalSommen(x, x);			
		}

		return nrOfSommen;
	}

	public long getAantalSommen() {
		return aantalSommen;
	}
}
