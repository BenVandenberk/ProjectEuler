package hulp;

public class Permutaties {
	
	private int[] collection;
	int[][] permutaties;
	int permutatieIndex;
	
	public Permutaties(int[] collection) {
		this.collection = collection;
		permutaties = new int[(int)aantalPermutaties()][];
		permutatieIndex = 0;
	}
	
	public int[][] getPermutaties() {
		permuteer(collection);
		return permutaties;
	}
	
	private void permuteer(int[] resterendeGetallen) {		
		
		if (resterendeGetallen.length == 2) {
			permutaties[permutatieIndex++] = new int[] {resterendeGetallen[0], resterendeGetallen[1]};
			permutaties[permutatieIndex++] = new int[] {resterendeGetallen[1], resterendeGetallen[0]};	
			return;
		}
		
		for (int i = resterendeGetallen.length - 1; i >= 0; i--) {
			int[] updatedResterendeGetallen = removeNumber(resterendeGetallen, i);
			int oudePermutatieIndex = permutatieIndex;
			permuteer(updatedResterendeGetallen);
			for (;oudePermutatieIndex < permutatieIndex; oudePermutatieIndex++) {
				permutaties[oudePermutatieIndex] = combineer(permutaties[oudePermutatieIndex], resterendeGetallen[i]);
			}			
		}
	}
	
	private int[] sizeUp(int[] input) {
		int[] result = new int[input.length + 1];
		for (int i = 0; i < input.length; i++) {
			result[i + 1] = input[i];
		}
		return result;
	}
	
	private int[] combineer(int[] set, int number) {
		set = sizeUp(set);
		set[0] = number;
		return set;
	}
	
	private int[] removeNumber(int[] set, int index) {
		int[] result = new int[set.length - 1];
		for (int i = 0, currIndex = 0; i < set.length; i++) {
			if (i == index) {
				continue;
			}
			result[currIndex++] = set[i];
		}
		return result;
	}
	
	private long aantalPermutaties() {
		long result = 1;
		for (int i = collection.length; i > 0; i--) {
			result *= i;
		}
		return result;
	}
}
