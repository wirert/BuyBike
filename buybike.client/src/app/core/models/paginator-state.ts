export class PaginatorState {
  constructor(
    public orderBy: string = 'Price',
    public desc: boolean = false,
    public itemsPerPage: number = 12,
    public pageNumber: number = 1
  ) {}
}
