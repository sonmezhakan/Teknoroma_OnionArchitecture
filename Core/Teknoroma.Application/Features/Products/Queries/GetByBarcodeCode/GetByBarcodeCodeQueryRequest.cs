using MediatR;

namespace Teknoroma.Application.Features.Products.Queries.GetByBarcodeCode
{
	public class GetByBarcodeCodeQueryRequest:IRequest<GetByBarcodeCodeQueryResponse>
	{
        public string BarcodeCode { get; set; }
    }
}
