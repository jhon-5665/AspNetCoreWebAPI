export class Util {
  static nameConcat(item: any[]): string {
    return item.map(x => x.name).join(',');
  }
}
