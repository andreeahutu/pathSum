using System;
using System.Collections.Generic;
using System.Text;
namespace dagSum {
      public class PathSum{
        private int sum;
        private List<int> path;
        public int Sum {
            get{
                return sum;
            }
        }
    
        public PathSum(int value){
            this.sum = value;
            this.path= new List<int>();
            this.path.Add(value);
        }
        public void addValue(int value){
            this.sum+=value;
            this.path.Add(value);
        }
        public List<int> Path{
            get{
                return path;
            }

        }
        public String PathString{
            get{
                StringBuilder s = new StringBuilder();
                for(int i=0; i< path.Count; i++){
                    if (i==path.Count-1){
                        s.Append(path[i]);
                    }
                    else {
                        s.Append(path[i]+", ");
                    }
                }
                return s.ToString();
            }
        }

        public String PrettyString{
           get{
                return "Max sum: "+Sum+"\nPath: "+PathString;
            }
           
        }
        public PathSum Clone(){
            PathSum result= null;
            if (path.Count<=0)
            return result;
            result = new PathSum(path[0]);
            for( int i=1; i< path.Count; i++){
                result.addValue(path[i]);
            }
            return result;
        }

    }

}