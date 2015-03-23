function Charlimit(elem,cnt) {
    if (elem.value.length > cnt) {
        return false;
    }
    return true;
}