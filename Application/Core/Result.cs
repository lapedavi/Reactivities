using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core {
    public class Result<T> {

        public bool isSucess {
            get;set;
        }

        public T value {
            get; set;
        }

        public string Error {
            get; set;
        }

        public static Result<T> Success(T value) => new Result<T> { isSucess = true, value = value };

        public static Result<T> Failure(string error) => new Result<T> { isSucess = false, Error = error };

    }
}
