***Изменения в приложении***

1. `AddProduct(ProductCreateRequest product)` - метод для добавления нового товара. Он принимает объект типа `ProductCreateRequest`, создает из него объект типа `Product`, добавляет его в базу данных и возвращает идентификатор добавленного товара.

2. `GetProducts()` - метод для получения списка всех товаров. Если список уже был загружен в кэш памяти, то возвращается кэшированный список, иначе запрос отправляется к базе данных для получения списка товаров.

3. `GetProductById(int id)` - метод для получения товара по его идентификатору. Он выполняет запрос к базе данных и возвращает соответствующий товар, если такой найден, или `null`, если товар с указанным идентификатором не существует.

4. `DeleteProduct(int id)` - метод для удаления товара по его идентификатору. Он ищет товар в базе данных по указанному идентификатору и удаляет его. Если товар был успешно удален, метод возвращает `true`, иначе - `false`.

5. `UpdatePrice(int id, decimal price)` - метод для обновления цены товара по его идентификатору. Он находит товар в базе данных по указанному идентификатору и обновляет его цену. Если обновление прошло успешно, метод возвращает `true`, иначе - `false`.

6. `DeleteCategory(string category)` - метод для удаления категории товаров. Он ищет все товары с указанной категорией и удаляет ссылку на эту категорию. После этого метод сохраняет изменения в базе данных и возвращает `true` в случае успешного удаления.
