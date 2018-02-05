package hulp;

import java.util.Arrays;

public class Combinaties {
	
	private int collectionSize;
	private int resultSize;
	private int[] collection;
	private int[] indices;
	
	public Combinaties(int collectionSize, int resultSize) {
		this.collectionSize = collectionSize;
		this.resultSize = resultSize;
		collection = new int[collectionSize];
		for (int i = 1; i <= collectionSize; i++) {
			this.collection[i - 1] = i;
		}
		indices = new int[resultSize];
		for (int i = 0; i < resultSize; i++) {
			indices[i] = i;
		}
	}
	
	public Combinaties(int[] collection, int resultSize) {
		this.collection = collection;
		Arrays.sort(this.collection);
		this.collectionSize = this.collection.length;
		this.resultSize = resultSize;
		indices = new int[resultSize];
		for (int i = 0; i < resultSize; i++) {
			indices[i] = i;
		}
	}
	
	public int[][] getCombinaties() {
		if (resultSize == 0) {
			throw new IllegalStateException("Combinaties van 0 elementen zijn niet zinvol.");
		}
		if (resultSize > collectionSize) {
			throw new IllegalStateException("Combinaties van meer elementen dan er elementen in de set zitten bestaan niet");			
		}

		int[][] result = new int[(int)aantalCombinaties()][];
		
		for (int i = 0; i < aantalCombinaties(); i++) {
			result[i] = new int[resultSize];
			for (int j = 0; j < indices.length; j++) {
				result[i][j] = collection[indices[j]];
			}
			if (!updateIndices()) {
				break;
			}
		}
		
		return result;		
	}
	
	private boolean updateIndices() {
		for (int i = indices.length - 1, j = 1; i >= 0; i--, j++) {
			if (indices[i] < collectionSize - j) {
				indices[i]++;
				for (int k = i + 1, plus = 1; k < indices.length; k++, plus++) {
					indices[k] = indices[i] + plus;
				}
				return true;
			}
		}
		return false;
	}
	
	private long aantalCombinaties() {
		long resultSizeFact = 1;
		for (int i = 2; i <= resultSize; i++) {
			resultSizeFact *= i;
		}
		long teller = collectionSize;
		for (int i = collectionSize - 1; i > collectionSize - resultSize; i--) {
			teller *= i;
		}
		return teller / resultSizeFact;
	}
}
