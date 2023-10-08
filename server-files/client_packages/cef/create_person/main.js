var parentList = [
    {gtaId: 0, name: 'Бенджамин'},
    {gtaId: 1, name: 'Даниэль'},
    {gtaId: 2, name: 'Джошва'},
    {gtaId: 3, name: 'Ноа'},
    {gtaId: 4, name: 'Эндрю'},
    {gtaId: 5, name: 'Джуан'},
    {gtaId: 6, name: 'Алекс'},
    {gtaId: 7, name: 'Исаак'},
    {gtaId: 8, name: 'Иван'},
    {gtaId: 9, name: 'Итан'},
    {gtaId: 10, name: 'Винсент'},
    {gtaId: 11, name: 'Анжел'},
    {gtaId: 12, name: 'Диего'},
    {gtaId: 13, name: 'Адриан'},
    {gtaId: 14, name: 'Габриель'},
    {gtaId: 15, name: 'Майкл'},
    {gtaId: 16, name: 'Сантиаго'},
    {gtaId: 17, name: 'Кевин'},
    {gtaId: 18, name: 'Луис'},
    {gtaId: 19, name: 'Самуэль'},
    {gtaId: 20, name: 'Энтони'},
    {gtaId: 21, name: 'Ханна'},
    {gtaId: 22, name: 'Одри'},
    {gtaId: 23, name: 'Джасмин'},
    {gtaId: 24, name: 'Джизель'},
    {gtaId: 25, name: 'Амелия'},
    {gtaId: 26, name: 'Изабелла'},
    {gtaId: 27, name: 'Зоя'},
    {gtaId: 28, name: 'Ава'},
    {gtaId: 29, name: 'Камила'},
    {gtaId: 30, name: 'Виолетта'},
    {gtaId: 31, name: 'София'},
    {gtaId: 32, name: 'Эвелина'},
    {gtaId: 33, name: 'Николь'},
    {gtaId: 34, name: 'Эшли'},
    {gtaId: 35, name: 'Грейси'},
    {gtaId: 36, name: 'Брианна'},
    {gtaId: 37, name: 'Натали'},
    {gtaId: 38, name: 'Оливия'},
    {gtaId: 39, name: 'Элизабет'},
    {gtaId: 40, name: 'Шарлотта'},
    {gtaId: 41, name: 'Эмма'},
    {gtaId: 42, name: 'Клод'},
    {gtaId: 43, name: 'Нико'},
    {gtaId: 44, name: 'Джон'},
    {gtaId: 45, name: 'Мисти'}
];

document.getElementById('btn-variation').onclick = function () 
{
    document.getElementById('clothes-switcher-id').style.display = 'none';
    document.getElementById('main-switch-clothes').style.display = 'none';
    document.getElementById('switch-variation-id').style.display = 'block';
    document.getElementById('clothes-verh-switch').style.display = 'none';
    document.getElementById('switch-pers-id').style.display = 'none';
    document.getElementById('reg-pers-vk').style.display = 'none';
}
document.getElementById('btn-nazad-niz').onclick = function () 
{
    document.getElementById('reg-pers-vk').style.display = 'none';
    document.getElementById('clothes-switcher-id').style.height = '320px';
     document.getElementById('clothes-switcher-id').style.width = '400px';
    document.getElementById('switch-variation-id').style.display = 'none';
    document.getElementById('main-switch-clothes').style.display = 'block';
    document.getElementById('switch-pers-id').style.display = 'none';
    document.getElementById('clothes-verh-switch').style.display = 'none';
   document.getElementById('reg-pers-vk').style.display = 'none';
}
document.getElementById('btn-clothes-verh').onclick = function () 
{
    document.getElementById('clothes-switcher-id').style.height = '700px';
    document.getElementById('clothes-switcher-id').style.width = '494px';
    document.getElementById('main-switch-clothes').style.display = 'none';
    
    document.getElementById('clothes-verh-switch').style.display = 'block';
    document.getElementById('reg-pers-vk').style.display = 'none';
}
document.getElementById('btn-clothes').onclick = function () 
{
  
    document.getElementById('reg-pers-vk').style.display = 'none';
    document.getElementById('switch-pers-id').style.display = 'none';
    document.getElementById('clothes-switcher-id').style.display = 'block';
    document.getElementById('main-switch-clothes').style.display = 'block';
    document.getElementById('switch-variation-id').style.display = 'none';
}
document.getElementById('btn-nasl').onclick = function () 
{
  
    document.getElementById('reg-pers-vk').style.display = 'none';
    document.getElementById('clothes-switcher-id').style.display = 'none';
    document.getElementById('switch-pers-id').style.display = 'block';
    document.getElementById('switch-variation-id').style.display = 'none';
    document.getElementById('main-switch-clothes').style.display = 'none';
   
}
document.getElementById('btn-per').onclick = function () 
{
    
    document.getElementById('reg-pers-vk').style.display = 'block';
    document.getElementById('clothes-switcher-id').style.display = 'none';
    document.getElementById('switch-pers-id').style.display = 'none';
    document.getElementById('switch-variation-id').style.display = 'none';
    document.getElementById('main-switch-clothes').style.display = 'none';
}

document.getElementById('btn-create-person').onclick = function () {
    
    var name = document.getElementById("change-name-input").value;

    var age = document.getElementById("change-year-input").value;

    const namePattern = /^[a-zA-Z0-9]{4,20}$/;
    if (!name.match(namePattern)) {
        document.getElementById('reg-error-name').style.display = 'block';
        return;
    }
    else {
        document.getElementById('reg-error-name').style.display = 'none';
    }
    
    const agePattern = /^[0-9]{1,3}$/;
    if (!age.match(agePattern)) {
        document.getElementById('reg-error-age').style.display = 'block';
        return;
    }
    else {
        document.getElementById('reg-error-age').style.display = 'none';
    }
    const parsedAge = parseInt(age);
    if (parsedAge < 21 || parsedAge > 100)
    {
        document.getElementById('reg-error-age').style.display = 'block';
        return;
    }
    else {
        document.getElementById('reg-error-age').style.display = 'none';
    }

    mp.trigger("CEF:CLIENT::PERSON_CREATE_BUTTON_CLICKED", name, age, gender)

};

