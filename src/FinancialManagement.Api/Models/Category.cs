using System.Collections.Generic;

namespace FinancialManagement.Api.Models
    {
    public class Category
        {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Relacionamento com Transactions via tabela de jun��o
        public ICollection<Transaction> Transactions { get; set; }
        }
    }
