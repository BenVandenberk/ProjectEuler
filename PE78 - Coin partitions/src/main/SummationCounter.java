package main;

import java.math.BigInteger;
import java.util.HashMap;

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
	private BigInteger aantalSommen;
	
	private HashMap<Punt, BigInteger> cache;

	public SummationCounter(int getal) {
		this.getal = getal;
		aantalSommen = BigInteger.ZERO;
		cache = new HashMap<Punt, BigInteger>();
	}

	public void run() {
		aantalSommen = aantalSommen(getal, getal);
	}

	public int getGetal() {
		return getal;
	}
	
	public void setGetal(int getal) {
		this.getal = getal;
	}

	private BigInteger aantalSommen(int x, int y) {
		BigInteger nrOfSommen = BigInteger.ZERO;
		Punt huidig = new Punt(x, y);

		if (y == 1) {
			return BigInteger.ONE;			
		}
		if (x == y) {
			return aantalSommen(x, y - 1).add(BigInteger.ONE);
		}
		
		if (cache.containsKey(huidig)) {
			return cache.get(huidig);
		}
		
		if (x == y + 1) {
			int xU = y;
			int yU = 1;
			for (; xU >= 1; xU--, yU++) {
				if (yU > xU) {
					nrOfSommen = nrOfSommen.add(aantalSommen(xU, xU));
				} else {
					nrOfSommen = nrOfSommen.add(aantalSommen(xU, yU));
				}
			}
		}
		if (x > y + 1) {
			int xU = x - y;
			int yU = y;
			for (; yU >= 1; yU--, xU++) {
				nrOfSommen = nrOfSommen.add(aantalSommen(xU, yU));
			}
		}
		if (x < y) {
			nrOfSommen = nrOfSommen.add(aantalSommen(x, x));			
		}
		
		cache.put(huidig, nrOfSommen);
		return nrOfSommen;
	}

	public BigInteger getAantalSommen() {
		return aantalSommen;
	}
}
