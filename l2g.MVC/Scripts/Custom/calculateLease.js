function calculateLease(price, mileage = 10000, month = 24) {
    const x1 = price / 10;
    const x2 = x1 * ((mileage / 1000) * 2) / 100;
    const x3 = x1 * (month / 2) / 100;
    const leasePrice = x1 + x2 - x3;
    return Number(leasePrice.toFixed(2));
}