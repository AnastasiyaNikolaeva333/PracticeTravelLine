import { render, screen } from '@testing-library/react';
import { Header } from '../components/CurrencyTransfer/Header/Header';
import { TableTranslation } from '../components/CurrencyTransfer/TableTranslation/TableTranslation';

describe('MoreAboutCurrencys Component', () => {

    it('отображает текс о курсе валют на текущий момент', () => {
        render(<Header />);
        expect(screen.getByText(/1 Polish zloty is/)).toBeTruthy();
        expect(screen.getByText(/0\.99 Japanese yen/)).toBeTruthy();
        expect(screen.getByText(/Fri, 05 Apr 2026 10:35 UTC/)).toBeTruthy();

    });

    it('отображает две строки', () => {
        const { container } = render(<TableTranslation />);
        const rows = container.querySelectorAll('[class*="rowTable"]');
        expect(rows).toHaveLength(2);
    });

    it('отображает PLN и JPY', () => {
        render(<TableTranslation />);
        expect(screen.getByText('PLN')).toBeInTheDocument();
        expect(screen.getByText('JPY')).toBeInTheDocument();
    });

    it('отображает значения 1 и 0,99', () => {
        render(<TableTranslation />);
        expect(screen.getByText('1')).toBeInTheDocument();
        expect(screen.getByText('0,99')).toBeInTheDocument();
    });

    it('отображает две кнопки', () => {
        render(<TableTranslation />);
        const buttons = screen.getAllByRole('button');
        expect(buttons).toHaveLength(2);
    });
});