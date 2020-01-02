using System;
using System.Collections.Generic;
using System.Text;
namespace dagSum {

      public class Dag{
        int[][] entryMatrix;
        PathSum[][] maxSumUntilNode ;
        int size;
        public Dag (string inputFile){
            string[] lines = System.IO.File.ReadAllLines(inputFile);
            this.size = lines.Length;
        
            entryMatrix = new int[size][];
            for(int i =0; i< size; i++){
                entryMatrix[i]= new int[size];
                string[] values = lines[i].Split(' ');

                for(int j=0; j< values.Length; j++){
                    entryMatrix[i][j] = Int32.Parse(values[j].Trim());
                }
            }
            maxSumUntilNode = new PathSum[size][];
            for(int i=0; i<size; i++){
                maxSumUntilNode[i] = new PathSum[size];
                for(int j=0; j<size; j++){
                    maxSumUntilNode[i][j]=null;
                }

            }
    
        }


        public PathSum getMaxSum(){
            PathSum max = null;
            int maxSum = Int32.MinValue;
            for( int j=0; j< size; j++){
                PathSum currentLeafMax = getMaxSumUntilNode(size-1,j);
            
                if (currentLeafMax!=null &&currentLeafMax.Sum>maxSum){
                    max = currentLeafMax;
                    maxSum=max.Sum;
                }
            }
            return max;
        }
        private PathSum getMaxSumUntilNode(int i, int j){
            if (i<0 || j<0){
                return null;
            }
            if (i==0){
                if ( j==0){
                     if (maxSumUntilNode[0][0]==null){
                         maxSumUntilNode[0][0]=new PathSum(entryMatrix[0][0]);
                }
                return maxSumUntilNode[0][0];

                }
                return null; 
            }
            if (maxSumUntilNode[i][j]!=null){
                return maxSumUntilNode[i][j];
            }
             
           if (CanBeUsedInSum(i,j)){
               PathSum max = null;
               int maxVal = Int32.MinValue;
               PathSum maxUntilParent1 =  getMaxSumUntilNode(i-1, j);
               PathSum maxUntilParent2 = getMaxSumUntilNode(i-1, j-1);
                if (maxUntilParent1!=null && maxUntilParent1.Sum> maxVal){
                    max = maxUntilParent1.Clone();
                    maxVal=max.Sum;
                }
                if(maxUntilParent2!=null && maxUntilParent2.Sum>maxVal){
                    max = maxUntilParent2.Clone();
                    maxVal= max.Sum;

                }
                if (max!=null){
                    max.addValue(entryMatrix[i][j]);
                }
                return max;
           }
           else {
               return null;
           }
           
        }

            //in order for the path to count against the max sum, 
            ///we need that the parity of the level is the right one
        
        public Boolean CanBeUsedInSum(int i, int j){
            if (i<0 || j<0 || i>= size || j>=size || j>i){
                return false;
            }

            Boolean keepLevelParity = entryMatrix[0][0]%2==0;
            int parityLevel = i%2;
            int parityNodeValue = entryMatrix[i][j]%2;
            return (keepLevelParity && parityLevel==parityNodeValue) 
            || (!keepLevelParity && parityLevel!=parityNodeValue);
        }

    }
}